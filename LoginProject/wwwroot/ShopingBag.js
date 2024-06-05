//const drowBaskets = (baskets) => {
//    // Select the <tbody> element
//    const tbody = document.querySelector("#items tbody");

//    // Select the <template> element
//    const template = document.getElementById("temp-row");

//    // For each product, create a new row and add it to the <tbody>
//    baskets.forEach(product => {
//        const clone = template.content.cloneNode(true);
//        clone.querySelector(".itemName").textContent = product.productName;
//        clone.querySelector(".availabilityColumn div").textContent = product.description;
//        clone.querySelector(".itemName").textContent = product.productName,
//        clone.querySelector(".price").textContent = product.price;
//        tbody.appendChild(clone);
//    });
//}

const getBasketFromStorage = () => {
    const baskets = JSON.parse(sessionStorage.getItem("basket"));
    if (baskets)
        drowBasket(baskets);

}

const addOrder = async () => {
    const order = {
        userId: JSON.parse(sessionStorage.getItem('user')).userId,
        orderItems: JSON.parse(sessionStorage.getItem("basket")),
        OrderSum: JSON.parse(sessionStorage.getItem("sumToPay"))
    }
    const response = await fetch("api/order", {

        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
    const data = await response.json()

    if (response.ok == false) {

        throw new Error(`error! status:${response.status}`)
    }
    else {
        alert("add order")
        clearStorage()
       
    }
}

clearStorage = () => {
    sessionStorage.removeItem('basket'),
        sessionStorage.removeItem('sumToPay')
    sessionStorage.removeItem("ItemsCountText")

 
}



const drowBasket = (products) => {

const template = document.getElementById('temp-row');
const tbody = document.querySelector('tbody');  // Assuming tbody is the target container

products.forEach(product => {
    const clone = document.importNode(template.content, true);

    // Populate with product data

    clone.querySelector('img').src = `../Images/${product.picture.trim()}.jpg`;
    clone.querySelector('.itemName').textContent = product.productName;
    clone.querySelector('.itemNumber').textContent = product.productId;
    clone.querySelector('.itemDescription').textContent = product.description;
    clone.querySelector('.price').textContent = product.price;
    clone.querySelector('.viewLink').href += "#" + product.productId;  // Assuming you append the product id to the URL

    tbody.appendChild(clone);
});
}




const updateBasket = () => {
    const sumToPay = sessionStorage.getItem("sumToPay");
    const countItems = sessionStorage.getItem("ItemsCountText");
    const currentSumElement = document.getElementById('totalAmount');
    const totalAmountElement = document.getElementById('itemCount');

    if (currentSumElement && sumToPay !== null) {
        currentSumElement.textContent = parseInt(sumToPay) || 0; // default to 0 if parse returns NaN
    }

    if (totalAmountElement && countItems !== null) {
        totalAmountElement.textContent = parseInt(countItems) || 0;
    }
}




updateBasket()

getBasketFromStorage()





