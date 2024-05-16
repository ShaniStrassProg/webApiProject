
const register = async () => {
    const user = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value,
        FirstName: document.getElementById("firstname").value,
        LastName: document.getElementById("lastname").value,
       
    }
    const response = await fetch(`api/users/${id}`, {
      
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const data = await response.json()
    if (response.ok == false) {
        alert(`status: ${response.status} username or password not good😒`);
        //throw new Error(`error! status:${response.status}`)
    }
    else {
        sessionStorage.setItem("user", JSON.stringify(data));
        window.location.href = "Products.html"      
    }
}


const update = async () => {
    const user = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value,
        FirstName: document.getElementById("firstname").value,
        LastName: document.getElementById("lastname").value,

    }
    const userRes =  JSON.parse(sessionStorage.getItem('user'))
    const response = await fetch("api/users/" + userRes.userId, {

        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
   
    
    if (response.ok==false) {

        throw new Error(`error! status:${response.status}`)
    }
    else {
        alert("update succesed!!")
    }
    window.location.href = "HomePage.html"
}



    const evalutePassword = async () => {
        const Password = document.getElementById("password").value
        const response = await fetch(`api/users/evalutePassword`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }, 
            body: JSON.stringify(Password)
        });
        const data = await response.json();
        document.getElementById("password-strength-progress").value = data
        console.log(data);
        
    }       



const login = async () => {
    console.log("gdcrctrf")
    
    const user = {
        Email: document.getElementById("email").value,
        Password: document.getElementById("password").value

    };
    const response = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const data = await response.json()
    if (!response.ok) {
        console.log("ssssssssssssssssss")
        throw new Error(`error! status:${response.status}`)
    }
    else {
        console.log("gdcrctrf")

        //sessionStorage.setItem("id", response.json.UserId);
        sessionStorage.setItem("user", JSON.stringify(data));
        window.location.href = "Products.html"        
    }
}


