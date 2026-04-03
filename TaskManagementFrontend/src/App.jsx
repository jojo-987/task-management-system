import React, { useState, useEffect, useCallback } from 'react';
import axios from 'axios';

const App = () => {
  const [users, setUsers] = useState([]);
  const [userName, setUserName] = useState('');
  const [email, setEmail] = useState('');

  const fetchUsers = useCallback(() => {
    axios.get('http://localhost:3000/api/user')
      .then(response => setUsers(response.data))
      .catch(err => console.error("Error fetching:", err));
  }, []);

  useEffect(() => {
    fetchUsers();
  }, [fetchUsers]);

  const handleSubmit = (e) => {
    e.preventDefault();
    const newUser = { userName, email };

    axios.post('http://localhost:3000/api/user', newUser)
      .then(() => {
        fetchUsers();
        setUserName('');
        setEmail('');
      })
      .catch(err => console.error('Error posting:', err));
  };

  return (
    <div style={styles.container}>
      <div style={styles.card}>
        <h2 style={styles.title}>User Management</h2>
        
        <form onSubmit={handleSubmit} style={styles.form}>
          <div style={styles.inputGroup}>
            <input
              type="text"
              placeholder="Username"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
              style={styles.input}
              required
            />
            <input
              type="email"
              placeholder="Email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              style={styles.input}
              required
            />
          </div>
          <button type="submit" style={styles.button}>Add User</button>
        </form>

        <hr style={styles.divider} />

        <h3 style={styles.subtitle}>User List</h3>
        <ul style={styles.list}>
          {users.map(user => (
            <li key={user.id} style={styles.listItem}>
              <div>
                <div style={styles.userName}>{user.userName}</div>
                <div style={styles.userEmail}>{user.email}</div>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

// Simple, modern JS-in-CSS styles
const styles = {
  container: {
    display: 'flex',
    justifyContent: 'center',
    padding: '40px 20px',
    backgroundColor: '#f4f7f6',
    minHeight: '100vh',
    fontFamily: 'Segoe UI, Tahoma, Geneva, Verdana, sans-serif'
  },
  card: {
    backgroundColor: '#fff',
    padding: '30px',
    borderRadius: '12px',
    boxShadow: '0 4px 6px rgba(0,0,0,0.1)',
    width: '100%',
    maxWidth: '500px',
    height: 'fit-content'
  },
  title: { margin: '0 0 20px 0', color: '#333', textAlign: 'center' },
  subtitle: { margin: '20px 0 15px 0', color: '#555' },
  form: { display: 'flex', flexDirection: 'column', gap: '15px' },
  inputGroup: { display: 'flex', flexDirection: 'column', gap: '10px' },
  input: {
    padding: '12px',
    borderRadius: '6px',
    border: '1px solid #ddd',
    fontSize: '14px',
    outline: 'none'
  },
  button: {
    padding: '12px',
    backgroundColor: '#007bff',
    color: 'white',
    border: 'none',
    borderRadius: '6px',
    cursor: 'pointer',
    fontWeight: 'bold',
    transition: 'background 0.2s'
  },
  divider: { border: '0', borderTop: '1px solid #eee', margin: '25px 0' },
  list: { listStyle: 'none', padding: 0, margin: 0 },
  listItem: {
    padding: '12px',
    borderBottom: '1px solid #f0f0f0',
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center'
  },
  userName: { fontWeight: '600', color: '#222' },
  userEmail: { fontSize: '13px', color: '#777' }
};

export default App;
