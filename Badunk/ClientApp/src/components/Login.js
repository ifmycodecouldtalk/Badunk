import React, { Component } from 'react';

export class Login extends Component {
    static displayName = Login.name;

    constructor(props) {
        super(props);
        this.state = {
            message: '',
            items: [],
            DataisLoaded: false
        };
    }

    /*onCreateUser = () => {
        let userInfo = 
        {
            'userName': this.refs.Name.value,
            'password': this.refs.Password.value
        };
        fetch('https://localhost:7232/api/users', {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify(userInfo)
        });
        this.setState({message: 'works?'})
    }*/

    onValidateUser = () => {
        
    }

    componentDidMount() {
        fetch(
            "https://localhost:7232/api/users")
            .then((res) => res.json())
            .then((json) => {
                this.setState({
                    items: json,
                    DataisLoaded: true
                });
            })
    }

    render() {
        const { DataisLoaded, items } = this.state;
        return (
            <div>

                <h2>Please Enter User Credentials...</h2>
                <p>
                    <label>UserName : <input type="text" ref="Name"></input></label>
                </p>
                <p>
                    <label>Password : <input type="text" ref="Password"></input></label>
                </p>
                <button onClick={this.onValidateUser}>Sign In</button>
                <p><strong>{this.state.message}</strong></p>

                {/*<h1> Fetch data from an api in react </h1>  {
                    items.map((item) => (
                        <ol key={item.id} >
                            User_Name: {item.userName},
                            Password: {item.password},
                        </ol>
                    ))
                }*/}
            </div>
        )
    }
}