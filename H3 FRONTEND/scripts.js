var token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXQgaW4gZXhlcmNpdGF0aW9uIiwiZXhwIjoxNjQ3MjU1NTQ1LCJpc3MiOiJodHRwczovL215d2ViYXBpLmNvbSIsImF1ZCI6Ik15IFdlYkFwaSBVc2VycyJ9.2x3V3-78lq0F8OuvCsy2SSnVgY7e2e7yUJbxxnXMWRk';

function Warehouses(){
    console.log("Sending Warehouses");
        var request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:7051/api/Warehouses');
    request.send();
    request.onload = ()=>{
        console.log(JSON.parse(request.response));
    }
}

function SingleWarehouse(){
    var id = document.getElementById("WarehouseID").value;
    console.log("Sending Warehouse with id");
        var request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:7051/api/Warehouses/'+id);
    request.send();
    request.onload = ()=>{
        console.log(JSON.parse(request.response));
    }
}

function Customers(){
    var myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer <token>");
     
    var requestOptions = {
      method: 'GET',
      headers: myHeaders,
      redirect: 'follow'
    };
     
    fetch("https://localhost:7051/api/Customers", requestOptions)
      .then(response => response.json())
      .then(result => console.log(result))
      .catch(error => console.log('error', error));
}