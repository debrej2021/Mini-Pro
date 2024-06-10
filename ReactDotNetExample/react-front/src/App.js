import logo from './logo.svg';
import './App.css';

import React, { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
    const [forecasts, setForecasts] = useState([]);

    useEffect(() => {
        //import axios from 'axios';

        function fetchData() {
            axios.get('http://localhost:5104/weatherforecast')
                .then(response => {
                    console.log('Data:', response.data);
                })
                .catch(error => {
                    console.error('Error fetching data:', error);
                });
        }

        fetchData();
    }, []);

    return (
        <div>
            <h1>Weather Forecast</h1>
            <ul>
                {forecasts.map(forecast => (
                    <li key={forecast.date}>
                        {new Date(forecast.date).toLocaleDateString()} - {forecast.temperatureC}°C - {forecast.summary}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;


//export default App;
