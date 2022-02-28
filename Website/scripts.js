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
    console.log("Sending Customers");
        var request = new XMLHttpRequest();
    request.open('GET', 'https://localhost:7051/api/Customers');
    request.send();
    request.onload = ()=>{
        console.log(JSON.parse(request.response));
    }
}