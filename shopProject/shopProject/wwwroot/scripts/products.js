function drawProducts(data) {
    data.forEach(product => {
        var temp = document.getElementById("temp-card");
        var clon = temp.content.cloneNode(true);
        clon.querySelector("h1").innerText = product.name;
        clon.querySelector("img").src = `../Pictures/${product.image}`;
        clon.querySelector(".price").innerText = `${product.price} $`;
        clon.querySelector(".description").innerText = product.description;
        document.body.appendChild(clon);
    })
}

//async function cleanPage() {
//    console.log("cleannnnnnnnnnnnnnnnn");
//    //document.body.getElementsByTagName("temp").clon = "";
//    //console.log(document.getElementById("PoductList"))
//    //document.getElementById("PoductList").remove();
//    document.getEltmentById("body").innerText = "";
//}

function drawCategories(data) {
    data.forEach(category => {
        var temp = document.getElementById("temp-category");
        var clon = temp.content.cloneNode(true);
        //clon.querySelector("h1").innerText = product.name;
        //clon.querySelector("img").src = `../pictures${product.img}`;
        //clon.querySelector(".price").innerText = `${product.price} $`;
        //clon.querySelector(".description").innerText = product.description;
        document.body.appendChild(clon);
    })
}


async function getProducts() {
    const response = await fetch(
        `api/Product`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        drawProducts(data);
    }
}

async function getCategories() {
    const response = await fetch(
        `/api/category`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json ; charest=utf-8'
        }
    }
    );
    if (!response.ok) {
        alert("categories are not exists");
    }
    else {
        const data = await response.json();
        drawCategories(data);
    }
}


//async function filterProducts() {

//     /*cleanPage();*/

//    let productName = document.getElementById("nameSearch").value;

//    const response = await fetch(
//        `/api/product/search/${productName}`, {

//        method: 'GET',
//        headers: {
//        'Content-Type': 'application/json ; charest=utf-8'}

//    }
//    )

//    if (!response.ok) {
//        alert("products are not exists");
//    }
//    else {
//        const data = await response.json();
//        drawProducts(data);
//    }
//}


async function filterProducts() {
    let productName = document.getElementById("nameSearch").value;
    console.log(productName);
    let minPrice = document.getElementById("minPrice").value;
    let maxPrice = document.getElementById("maxPrice").value;


    const response = await fetch(
        `/api/product/search?desc=${productName}&minPrice=${minPrice}&maxPrice=${maxPrice}`, {

        method: 'GET',
        headers: {
        'Content-Type': 'application/json ; charest=utf-8'}

    }
    )

    if (!response.ok) {
        alert("products are not exists");
    }
    else {
        const data = await response.json();
        drawProducts(data);
    }
}


document.addEventListener("load", getProducts);






