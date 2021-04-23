import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { List, ListItem, ListItemText } from '@material-ui/core';

function App() {

  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5005/api/Activities').then(response => {
      console.log(response);
      setActivities(response.data);
    })
  }, [])

  return (
    <div className="App">
      <List>
          {activities.map((activity: any) => (
            <ListItem key={activity.id}>
              <ListItemText primary={activity.title} />
            </ListItem>
          ))}
        </List>
    </div>
  );
}

export default App;
