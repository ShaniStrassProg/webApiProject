
const login = async () => {

    const user = {
    Email: document.getElementById("email").value,
    Password: document.getElementById("password").value

};
    const response = await fetch('api/users/login', {
        method: 'POST',
        headers: {
            'Content-Type':'application/json'
        },
        body: JSON.stringify(user)                                                           
    });
    if (!response.ok) {
        throw new Error(`error! status:${response.status}`)
    }
    else {
       
        window.location.href="Update.html"


    }
}

