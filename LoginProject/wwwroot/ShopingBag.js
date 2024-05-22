const drowBaskets = (baskets) => {

    // Select the <tbody> element
    const tbody = document.querySelector("#items tbody");

    // Select the <template> element
    const template = document.getElementById("temp-row");

    // For each product, create a new row and add it to the <tbody>
    baskets.forEach(product => {
        const clone = template.content.cloneNode(true);
        clone.querySelector(".itemName").textContent = product.productName;
        clone.querySelector(".availabilityColumn div").textContent = product.description;
        clone.querySelector(".price").textContent = product.price;

        tbody.appendChild(clone);
    });
}
const getBasketFromStorage = () => {
    const baskets = JSON.parse(sessionStorage.getItem("basket"));
    if (baskets)
        drowBaskets(baskets);

}

const addOrder = async () => {
    const order = {
        userId: JSON.parse(sessionStorage.getItem('user')).userId,
        orderItems: JSON.parse(sessionStorage.getItem("basket"))

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
        sessionStorage.removeItem('basket')
    }
}

















getBasketFromStorage()





