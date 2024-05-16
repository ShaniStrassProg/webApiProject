const addOrder = async () => {
    const order = {
        orderSum: document.getElementById("sum").value,
        userId: JSON.parse(sessionStorage.getItem('user')).userId
         
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
        return data.orderId
    }
}
  

