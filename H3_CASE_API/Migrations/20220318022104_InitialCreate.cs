using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace H3_CASE_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        CategoryID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.CategoryID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contact_Type",
            //    columns: table => new
            //    {
            //        Contact_TypeID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ContactType = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contact_Type", x => x.Contact_TypeID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Delivery_Service",
            //    columns: table => new
            //    {
            //        Delivery_ServiceID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Courier_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Delivery_Service", x => x.Delivery_ServiceID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Manufactor",
            //    columns: table => new
            //    {
            //        ManufactorID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Manufactor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Manufactor", x => x.ManufactorID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PostalCodes",
            //    columns: table => new
            //    {
            //        PostalCode = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostalCodes", x => x.PostalCode);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product_Status",
            //    columns: table => new
            //    {
            //        Product_StatusID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product_Status", x => x.Product_StatusID);
            //    });


            //migrationBuilder.CreateTable(
            //    name: "Contact_Informaition",
            //    columns: table => new
            //    {
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Contact_TypeID = table.Column<int>(type: "int", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contact_Informaition", x => x.Contact_InformaitionID);
            //        table.ForeignKey(
            //            name: "FK_Contact_Informaition_Contact_Type_Contact_TypeID",
            //            column: x => x.Contact_TypeID,
            //            principalTable: "Contact_Type",
            //            principalColumn: "Contact_TypeID");
            //    });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contact_InformaitionID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                                        table.ForeignKey(
                        name: "FK_Users_Contact_InformaitionID",
                        column: x => x.Contact_InformaitionID,
                        principalTable: "Contact_Informaition",
                        principalColumn: "Contact_InformaitionID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        ProductID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CategoryID = table.Column<int>(type: "int", nullable: false),
            //        ManufactorID = table.Column<int>(type: "int", nullable: false),
            //        Product_StatusID = table.Column<int>(type: "int", nullable: false),
            //        Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        In_Price = table.Column<double>(type: "float", nullable: false),
            //        Out_Price = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.ProductID);
            //        table.ForeignKey(
            //            name: "FK_Product_Category_CategoryID",
            //            column: x => x.CategoryID,
            //            principalTable: "Category",
            //            principalColumn: "CategoryID");
            //        table.ForeignKey(
            //            name: "FK_Product_Manufactor_ManufactorID",
            //            column: x => x.ManufactorID,
            //            principalTable: "Manufactor",
            //            principalColumn: "ManufactorID");
            //        table.ForeignKey(
            //            name: "FK_Product_Product_Status_Product_StatusID",
            //            column: x => x.Product_StatusID,
            //            principalTable: "Product_Status",
            //            principalColumn: "Product_StatusID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Addrese",
            //    columns: table => new
            //    {
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false),
            //        AddreseID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostalCode = table.Column<int>(type: "int", nullable: false),
            //        Addrese_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Addrese", x => x.AddreseID);
            //        table.ForeignKey(
            //            name: "FK_Addrese_Contact_Informaition_Contact_InformaitionID",
            //            column: x => x.Contact_InformaitionID,
            //            principalTable: "Contact_Informaition",
            //            principalColumn: "Contact_InformaitionID");
            //        table.ForeignKey(
            //            name: "FK_Addrese_PostalCodes_PostalCode",
            //            column: x => x.PostalCode,
            //            principalTable: "PostalCodes",
            //            principalColumn: "PostalCode");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customer",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customer", x => x.CustomerID);
            //        table.ForeignKey(
            //            name: "FK_Customer_Contact_Informaition_Contact_InformaitionID",
            //            column: x => x.Contact_InformaitionID,
            //            principalTable: "Contact_Informaition",
            //            principalColumn: "Contact_InformaitionID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Department",
            //    columns: table => new
            //    {
            //        DepartmentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Department", x => x.DepartmentID);
            //        table.ForeignKey(
            //            name: "FK_Department_Contact_Informaition_Contact_InformaitionID",
            //            column: x => x.Contact_InformaitionID,
            //            principalTable: "Contact_Informaition",
            //            principalColumn: "Contact_InformaitionID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        EmployeeID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentID = table.Column<int>(type: "int", nullable: false),
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.EmployeeID);
            //        table.ForeignKey(
            //            name: "FK_Employee_Contact_Informaition_Contact_InformaitionID",
            //            column: x => x.Contact_InformaitionID,
            //            principalTable: "Contact_Informaition",
            //            principalColumn: "Contact_InformaitionID");
            //        table.ForeignKey(
            //            name: "FK_Employee_Department_DepartmentID",
            //            column: x => x.DepartmentID,
            //            principalTable: "Department",
            //            principalColumn: "DepartmentID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Warehouse",
            //    columns: table => new
            //    {
            //        WarehouseID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepartmentID = table.Column<int>(type: "int", nullable: false),
            //        Contact_InformaitionID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Warehouse", x => x.WarehouseID);
            //        table.ForeignKey(
            //            name: "FK_Warehouse_Contact_Informaition_Contact_InformaitionID",
            //            column: x => x.Contact_InformaitionID,
            //            principalTable: "Contact_Informaition",
            //            principalColumn: "Contact_InformaitionID");
            //        table.ForeignKey(
            //            name: "FK_Warehouse_Department_DepartmentID",
            //            column: x => x.DepartmentID,
            //            principalTable: "Department",
            //            principalColumn: "DepartmentID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        OrdersID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerID = table.Column<int>(type: "int", nullable: false),
            //        EmployeeID = table.Column<int>(type: "int", nullable: false),
            //        Delivery_ServiceID = table.Column<int>(type: "int", nullable: false),
            //        Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Shipment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Delivery_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.OrdersID);
            //        table.ForeignKey(
            //            name: "FK_Orders_Customer_CustomerID",
            //            column: x => x.CustomerID,
            //            principalTable: "Customer",
            //            principalColumn: "CustomerID");
            //        table.ForeignKey(
            //            name: "FK_Orders_Delivery_Service_Delivery_ServiceID",
            //            column: x => x.Delivery_ServiceID,
            //            principalTable: "Delivery_Service",
            //            principalColumn: "Delivery_ServiceID");
            //        table.ForeignKey(
            //            name: "FK_Orders_Employee_EmployeeID",
            //            column: x => x.EmployeeID,
            //            principalTable: "Employee",
            //            principalColumn: "EmployeeID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product_Stock",
            //    columns: table => new
            //    {
            //        Product_StockID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProductID = table.Column<int>(type: "int", nullable: false),
            //        WarehouseID = table.Column<int>(type: "int", nullable: false),
            //        Ammount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product_Stock", x => x.Product_StockID);
            //        table.ForeignKey(
            //            name: "FK_Product_Stock_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "ProductID");
            //        table.ForeignKey(
            //            name: "FK_Product_Stock_Warehouse_WarehouseID",
            //            column: x => x.WarehouseID,
            //            principalTable: "Warehouse",
            //            principalColumn: "WarehouseID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderLine",
            //    columns: table => new
            //    {
            //        OrderLineID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        OrdersID = table.Column<int>(type: "int", nullable: false),
            //        ProductID = table.Column<int>(type: "int", nullable: false),
            //        Ammount = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderLine", x => x.OrderLineID);
            //        table.ForeignKey(
            //            name: "FK_OrderLine_Orders_OrdersID",
            //            column: x => x.OrdersID,
            //            principalTable: "Orders",
            //            principalColumn: "OrdersID");
            //        table.ForeignKey(
            //            name: "FK_OrderLine_Product_ProductID",
            //            column: x => x.ProductID,
            //            principalTable: "Product",
            //            principalColumn: "ProductID");
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Addrese_Contact_InformaitionID",
            //    table: "Addrese",
            //    column: "Contact_InformaitionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Addrese_PostalCode",
            //    table: "Addrese",
            //    column: "PostalCode");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contact_Informaition_Contact_TypeID",
            //    table: "Contact_Informaition",
            //    column: "Contact_TypeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customer_Contact_InformaitionID",
            //    table: "Customer",
            //    column: "Contact_InformaitionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Department_Contact_InformaitionID",
            //    table: "Department",
            //    column: "Contact_InformaitionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_Contact_InformaitionID",
            //    table: "Employee",
            //    column: "Contact_InformaitionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_DepartmentID",
            //    table: "Employee",
            //    column: "DepartmentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderLine_OrdersID",
            //    table: "OrderLine",
            //    column: "OrdersID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderLine_ProductID",
            //    table: "OrderLine",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerID",
            //    table: "Orders",
            //    column: "CustomerID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_Delivery_ServiceID",
            //    table: "Orders",
            //    column: "Delivery_ServiceID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_EmployeeID",
            //    table: "Orders",
            //    column: "EmployeeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_CategoryID",
            //    table: "Product",
            //    column: "CategoryID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_ManufactorID",
            //    table: "Product",
            //    column: "ManufactorID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_Product_StatusID",
            //    table: "Product",
            //    column: "Product_StatusID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_Stock_ProductID",
            //    table: "Product_Stock",
            //    column: "ProductID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Product_Stock_WarehouseID",
            //    table: "Product_Stock",
            //    column: "WarehouseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Warehouse_Contact_InformaitionID",
            //    table: "Warehouse",
            //    column: "Contact_InformaitionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Warehouse_DepartmentID",
            //    table: "Warehouse",
            //    column: "DepartmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Addrese");

            //migrationBuilder.DropTable(
            //    name: "OrderLine");

            //migrationBuilder.DropTable(
            //    name: "Product_Stock");

            migrationBuilder.DropTable(
                name: "Users");

            //migrationBuilder.DropTable(
            //    name: "PostalCodes");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "Product");

            //migrationBuilder.DropTable(
            //    name: "Warehouse");

            //migrationBuilder.DropTable(
            //    name: "Customer");

            //migrationBuilder.DropTable(
            //    name: "Delivery_Service");

            //migrationBuilder.DropTable(
            //    name: "Employee");

            //migrationBuilder.DropTable(
            //    name: "Category");

            //migrationBuilder.DropTable(
            //    name: "Manufactor");

            //migrationBuilder.DropTable(
            //    name: "Product_Status");

            //migrationBuilder.DropTable(
            //    name: "Department");

            //migrationBuilder.DropTable(
            //    name: "Contact_Informaition");

            //migrationBuilder.DropTable(
            //    name: "Contact_Type");
        }
    }
}
