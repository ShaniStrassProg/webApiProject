
let categoryArr = [];

const conditionMet=false

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
    //conditionMet= true
    updateSum()
}


const updateSum =  (sum) => {
    const currentSum = sessionStorage.getItem('sumToPay') || 0;    
    //const currentSum = parseInt(document.getElementById('sum').textContent);
    const newSum = currentSum + sum;
    sessionStorage.setItem('sumToPay', newSum)
}

const getCategories = async () => {

    const response = await fetch('api/category')

    if (!response.ok) {
        throw new Error(`error! status:${response.status}`)
    }
    else {
        const data = await response.json()
        console.log(data)
        drowCategories(data)

    }
}


const drowCategories = (data) => {

    const template = document.getElementById("temp-category");

    data.forEach(category => {
        const card = template.content.cloneNode(true)
        card.querySelector('.opt').id = category.categoryId
        card.querySelector('.opt').value = category.categoryName
        card.querySelector('label').for = category.categoryName
        card.querySelector('.OptionName').textContent = category.categoryName
        card.querySelector('.opt').addEventListener("change", (event) => { filterCategories(event, category) })

        document.getElementById("categoryList").appendChild(card)
    })


}

const filterProducts = async () => {
    const maxPrice = document.getElementById("maxPrice").value;
    const minPrice = document.getElementById("minPrice").value;
    const productName = document.getElementById("nameSearch").value;
    let c = ''
    categoryArr.forEach(e => c += `&categoryIds=${e}`)
    const responsePost = await fetch(`api/Product?minPrice=${minPrice}&maxPrice=${maxPrice}&desc=${productName}${c}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    const dataPost = await responsePost.json();
    console.log(dataPost)
    document.getElementById("ProductList").replaceChildren();
    drowProducts(dataPost);

}



const filterCategories = async (event, category) => {
    if (event.target.checked) {
        categoryArr.push(category.categoryId)
        filterProducts();
    }
    else {
        categoryArr.splice(categoryArr.indexOf(category.categoryId), 1)
        filterProducts();
    }

}

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

const drawBasket = () => {
    const productsArr = JSON.parse(sessionStorage.getItem("basket"));
    const template = document.getElementById('temp-row');
    productsArr.forEach(product => {
        const row = template.content.cloneNode(true);
        row.querySelector(".price").innerText = product.price;
        row.querySelector(".image").src = '../Images/' + product.imageUrl;
        row.querySelector(".descriptionColumn").innerText = product.description;
        row.querySelector('img').src = '../Images/' + product.imageUrl;
        document.getElementById("PoductList").appendChild(row);
    });

}










getCategories()
getAllProducts()
//setInterval(updateValue, 2000);




