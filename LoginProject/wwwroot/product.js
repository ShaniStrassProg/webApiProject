const drowProducts = (products) => {
    const template = document.getElementById('temp-card');

    products.forEach(product => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('img').src = `../Images/${product.picture.trim()}.jpg`;
        clone.querySelector('h1').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price;
        clone.querySelector('.description').textContent = product.description;

        clone.querySelector('button').addEventListener('click', () => {
            updateProductInStorage(product)
        });

        document.getElementById('ProductList').appendChild(clone);
    });
}
const conditionMet=false
const getAllProducts = async () => {

    const response = await fetch('api/product')
    
    if (!response.ok) {
        throw new Error(`error! status:${response.status}`)
    }
    else {
        const data = await response.json()
        console.log(data)
        drowProducts(data)

    }
}

function updateProductInStorage(prod) {
    const basket = JSON.parse(sessionStorage.getItem('basket')) || [];
    const productIndex = basket.findIndex(product => product.productId === prod.productId);
    console.log(productIndex)
    if (productIndex !== -1) {
        basket[productIndex].quaninty++;
    } else {
        prod = { ...prod, quaninty :1 }
        basket.push(prod);
    }

    sessionStorage.setItem('basket', JSON.stringify(basket));
    sessionStorage.setItem("price",prod.price)
    conditionMet= true
    updateSum()
}
const updateSum = () => {
    const sum = sessionStorage.getItem('price')
    const currentSum = parseInt(document.getElementById('sum').textContent);
    const newSum = currentSum + sum;
    document.getElementById('sum').textContent = newSum;
}   

getAllProducts()
setInterval(updateValue, 2000);




