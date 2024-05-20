import { useEffect, useState } from 'react';
import './App.css';
import {DialogContent, TextField, Button} from '@mui/material';
// import Time from 'react-time';



function App() {
    const [newPet, setNewPet] = useState({
        name: '',
        created_at: '',
        type: '',
        color: '#ffffff',
        age: ''
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setNewPet(prevState => ({ ...prevState, [name]: value }));
    };

    const fetchNewPet = async (form) => {
        console.log("in fetch")
        const response = await fetch('https://localhost:7023/api/pets', {
                method: 'POST',
                
                body: form
            });

            if (!response.ok) {
                throw new Error("Failed to add pet");
            }
            const data = await response.json();
            return data;
    }

    const handleAddPet = async () => {
        console.log("in handle add");
        if(newPet.name.length > 25){
            alert("Name is too lond!");
            return;
        }
        if(newPet.name.length === 0){
            alert("no name typed...");
            return;
        }
        if(newPet.age > 20){
            alert("Too old (20 is max)");
            return;
        }
        if(newPet.age < 0){
            alert("Age doesnt make sense");
            return;
        }

        
        const formData = new FormData();
        formData.append('name', newPet.name);
        const date = new Date();
        console.log(date);
        formData.append('created_at',date)
        formData.append('type', newPet.type);
        formData.append('color', newPet.color);
        formData.append('age', newPet.age);
        
        
        console.log(formData);

        fetchNewPet(formData);
            
        setNewPet({
            name: '',
            created_at: '',
            type: '',
            color: '#ffffff',
            age: ''
        });
        // update form to empty
    };
    

    return (
        <div className='page'>
            <h1 id="tabelLabel">Welcome to Pets!</h1>
            <div className='container'>
                <Button>See all pets</Button>
                <br/>
                <DialogContent>Here you can add a pet!</DialogContent>
                <DialogContent>
                <form onSubmit={(e) => { e.preventDefault(); handleAddPet(); }}>
                <TextField
                            margin="dense"
                            label="Pet Name"
                            name="name"
                            value={newPet.name}
                            onChange={handleInputChange}
                            fullWidth
                            required
                        />
                        <TextField
                            margin="dense"
                            label="Type of pet"
                            name="type"
                            type="text"
                            value={newPet.type}
                            onChange={handleInputChange}
                            fullWidth
                            required
                        />
                        <TextField
                            margin="dense"
                            label="color"
                            name="color"
                            // value={newPet.color}
                            onChange={handleInputChange}
                            fullWidth
                            required
                        />
                        <TextField
                            margin="dense"
                            label="age"
                            name="age"
                            value={newPet.age}
                            onChange={handleInputChange}
                            fullWidth
                            required
                        />
                </form>
                <Button onClick={handleAddPet} color="primary">
                        Submit
                </Button>
                </DialogContent>

            </div>
            
        </div>
    );
    
    
}

export default App;