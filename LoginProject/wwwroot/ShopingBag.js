function addToBasket(prod) {

    const basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    const productIndex = basket.findIndex(product => product.productId === prod.productId);
    if (productIndex !== -1) {
        basket[productIndex].quaninty++;
    } else {
        prod = { ...prod, quaninty: 1 }
        basket.push(prod);
    }

    sessionStorage.setItem('basket', JSON.stringify(basket));
    updateSum(prod.price)
    counter(+1)
    updateBasket()
    alert("add")
    
  
}

const removeFromBasket = (prop) => {
    const basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    const productIndex = basket.findIndex(product => product.productId === prop.productId);
    if (productIndex !== -1) {
        basket.splice(productIndex, 1);
        sessionStorage.setItem('basket', JSON.stringify(basket));
    }
    alert("remove")
    updateSum(-1*(prop.price * prop.quaninty))
    counter(-prop.quaninty)
    updateBasket()
   
    
}
function decreaseFromBasket(prod) {
    const basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    const productIndex = basket.findIndex(product => product.productId === prod.productId);
        if (basket[productIndex].quaninty == 1)
    removeFromBasket(prod)
        else {
        basket[productIndex].quaninty--
        sessionStorage.setItem('basket', JSON.stringify(basket));
        updateSum(-prod.price)
        counter(-1)
    }
    alert("decrease")
    updateBasket()
    
}

const updateSum = async (sum) => {
    const newSum = JSON.parse(sessionStorage.getItem("sumToPay"));
    sessionStorage.setItem('sumToPay', newSum)
}
const counter = (c) => {
    const newCount = JSON.parse(sessionStorage.getItem("ItemsCountText"));
    sessionStorage.setItem('ItemsCountText', newCount)
}


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
    clone.querySelector('.itemNumber').textContent = product.quaninty;
    clone.querySelector('.itemDescription').textContent = product.description;
    clone.querySelector('.price').textContent = product.price * product.quaninty;
    clone.querySelector('.removeButton').addEventListener('click', () => {
        decreaseFromBasket(product)
    });
    clone.querySelector('.addButton').addEventListener('click', () => {
        addToBasket(product)
    });
    clone.querySelector('.removeProduct').addEventListener('click', () => {
        removeFromBasket(product)
    });
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
    getBasketFromStorage()
}




updateBasket()

getBasketFromStorage()





