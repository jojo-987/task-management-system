import React, { useState, useEffect } from 'react';
import axios from 'axios';

const App = () => {
  const [users, setUsers] = useState([]);
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');

  useEffect(() => {
    axios.get('http://task-management-backend:3000/api/user')
      .then(response => {
        setUsers(response.data);
      })
      .catch(error => {
        console.error("Error fetching data:", error);
      });
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const newUser = { userName, email };

    axios.post('http://task-management-backend:3000/api/user', newUser)
      .then(response => {
        console.log('Success:', response.data);
        alert('User added!');
        // Optional: clear inputs
        setUserName('');
        setEmail('');
      })
      .catch(error => {
        console.error('Error posting data:', error);
      });
  };

  return (
    <div>
    <form onSubmit={handleSubmit} style={{ margin: '20px 0' }}>
      <input
        type="text"
        placeholder="Username"
        value={userName}
        onChange={(e) => setUserName(e.target.value)}
        required
      />
      <input
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        required
      />
      <button type="submit">Add User</button>
    </form>
      <h2>User List</h2>
      <ul>
        {users.map(user => (
          <li key={user.id} style={{ marginBottom: '10px' }}>
            <strong>Name:</strong> {user.userName} <br />
            <strong>Email:</strong> {user.email}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default App;

