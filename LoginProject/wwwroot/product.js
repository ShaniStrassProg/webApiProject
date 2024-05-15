const drowProducts = (products) => {
    const template = document.getElementById('temp-card');

    products.forEach(product => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('img').src = `../Images/${product.picture.trim()}.jpg`;
        clone.querySelector('h1').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price;
        clone.querySelector('.description').textContent = product.description;

        clone.querySelector('button').addEventListener('click', () => {

            console.log('Product added to cart:', product.Description);
        });

        document.getElementById('ProductList').appendChild(clone);
    });
}

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
getAllProducts()