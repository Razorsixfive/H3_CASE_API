using H3_CASE_API.Entities.Dto;
using H3_CASE_API.Entities.Views;
using H3_CASE_API.Entities;

namespace H3_CASE_API.Repository
{
    public interface ICustomerRepos
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int Id);
        IEnumerable<Orders> GetCustomerOrders(int Id);
        OrdersDto FindTotalPrice(OrdersDto _OrdersDto);
        OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders);
        Task<bool> AddCustomer(InputDataModels.PostCustomer _input);
        Task<Customer> UpdateCustomer(int CustomerID, InputDataModels.PutCustomer _input);
        Task<Addrese> AddCustomer_Addrese(int CustomerID, InputDataModels.Post_Addrese _input);
        Task<bool> UpdateCustomer_Addrese(int AddreseID, InputDataModels.Post_Addrese _input, int CustomerID);
        Task<bool> DeleteCustomer_Addrese(int AddreseID, int contactID);
        bool CustomerExists(int Id);
        bool Save();
    }

    public class CustomerRepos : ICustomerRepos 
    {
        private readonly MainDBContext _context;

        public CustomerRepos(MainDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddCustomer(InputDataModels.PostCustomer _input)
        {
            var _Customer = new Customer(_input);

            _context.Contact_Informaition.Add(_Customer.Contact_Informaition);
            _context.SaveChanges();

            foreach(InputDataModels.Post_Addrese _Addrese in _input.addreses){
                _context.Addrese.Add(new Addrese(_Addrese, _Customer.Contact_Informaition.Contact_InformaitionID));
                _context.SaveChanges();
            }

            _context.Customer.Add(_Customer);
            _context.SaveChanges();

            return true;
        }

        public bool CustomerExists(int Id)
        {
            return _context.Customer.Any(e => e.CustomerID == Id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var data = _context.Customer
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Contact_Type)
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .ToList();

            return data;
        }

        public Customer GetCustomer(int Id)
        {
            var data = _context.Customer
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Contact_Type)
                .Include(x => x.Contact_Informaition)
                    .ThenInclude(Contact_Informaition => Contact_Informaition.Addrese)
                        .ThenInclude(Addrese => Addrese.PostalCodes)
                .FirstOrDefault(x => x.CustomerID == Id);
            return data;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<Customer> UpdateCustomer(int CustomerID, InputDataModels.PutCustomer _input)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(x=>x.CustomerID == CustomerID);
            var _Contact = await _context.Contact_Informaition.FirstOrDefaultAsync(x=>x.Contact_InformaitionID == customer.Contact_InformaitionID);
                _Contact.Contact_TypeID = _input.ContactTypeID;
                _Contact.Email = _input.Email;
                _Contact.First_Name = _input.First_Name;
                _Contact.Last_Name = _input.Last_Name;
                _Contact.Phone_Number = _input.Phone_Number;
                _Contact.Mobile_Number = _input.Mobile_Number;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Addrese> AddCustomer_Addrese(int CustomerID, InputDataModels.Post_Addrese _input)
        {
            var _Customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerID == CustomerID);
            var _Contact  = await _context.Contact_Informaition.FirstOrDefaultAsync(x => x.Contact_InformaitionID == _Customer.Contact_InformaitionID);

            var _Addrese = new Addrese(_input, _Contact.Contact_InformaitionID);
            _context.Addrese.Add(_Addrese);
            await _context.SaveChangesAsync();
            return _Addrese;
        }

        public async Task<bool> DeleteCustomer_Addrese(int addreseID, int contactID)
        {
            var _addrese = await _context.Addrese.FindAsync(addreseID);
            if (_addrese == null) { return false; }
            if(contactID == _addrese.Contact_InformaitionID)
            {
                _context.Addrese.Remove(_addrese);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateCustomer_Addrese(int AddreseID, InputDataModels.Post_Addrese _input, int CustomerID)
        {
            var _Customer = await _context.Customer.FindAsync(CustomerID);
            var _Addrese = await _context.Addrese.FindAsync(AddreseID);
            if (_Addrese.Contact_InformaitionID == _Customer.Contact_InformaitionID && _Customer != null && _Addrese != null)
            {
                _Addrese.Addrese_Name = _input.Addrese_Name;
                _Addrese.PostalCode = _input.PostalCode;
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<Orders> GetCustomerOrders(int Id)
        {
            var Order = _context.Orders
                .Include(x => x.Customer)
                .Include(x => x.Employee)
                .Include(x => x.Delivery_Service)
                .Include(x => x.OrderLines)
                .Where(x => x.CustomerID == Id);
            return Order;
        }

        public OrdersDto FindTotalPrice(OrdersDto _OrdersDto)
        {
            double Price = 0;
            foreach (OrderLineDto item in _OrdersDto.OrderLines)
            {
                Price += item.Price;
            }
            _OrdersDto.TotalPrice = Price;

            return _OrdersDto;
        }

        public OrdersView FilterIntoView(IEnumerable<OrdersDto> Orders)
        {
            OrdersView _OrdersView = new OrdersView();
            _OrdersView.Delivery_Service = _context.Delivery_Service;
            _OrdersView.Orders = Orders;
            return _OrdersView;
        }
    }
}
