function attachEvents() {
    let getWeatherButtonElement = document.getElementById('submit');
    let inputLocationElement = document.getElementById('location');
    let forecastElement = document.getElementById('forecast');
    let currentConditionElement = document.getElementById('current');
    let upcomingConditionElement = document.getElementById('upcoming');

    getWeatherButtonElement.addEventListener('click', () => {
        forecastElement.style.display = 'block';
        fetch('http://localhost:3030/jsonstore/forecaster/locations')
            .then(res => res.json())
            .then((data) => {
                for (const location of data) {
                    if (location.name == inputLocationElement.value) {
                        fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
                            .then(res => res.json())
                            .then((forecast) => {
                                currentConditionElement.innerHTML = '';

                                let newForecast = document.createElement('div');
                                newForecast.classList = 'forecasts';

                                let conditionSymbol = document.createElement('span');
                                if (forecast.forecast.condition == 'Rain') {
                                    conditionSymbol.textContent = '\u2614';
                                } else if (forecast.forecast.condition == 'Sunny') {
                                    conditionSymbol.textContent = '\u2600';
                                } else if (forecast.forecast.condition == 'Partly sunny') {
                                    conditionSymbol.textContent = '\u26C5';
                                } else if (forecast.forecast.condition == 'Overcast') {
                                    conditionSymbol.textContent = '\u2601';
                                }
                                conditionSymbol.classList = 'condition symbol';
                                newForecast.appendChild(conditionSymbol);

                                let forecastData = document.createElement('div');
                                forecastData.classList = 'condition';

                                let forecastDataName = document.createElement('span');
                                forecastDataName.textContent = forecast.name;
                                forecastDataName.classList = 'forecast-data';
                                forecastData.appendChild(forecastDataName);
                                let forecastDataTemperature = document.createElement('span');
                                forecastDataTemperature.textContent = `${forecast.forecast.low}°/${forecast.forecast.high}°`;
                                forecastDataTemperature.classList = 'forecast-data';
                                forecastData.appendChild(forecastDataTemperature);
                                let forecastDataCondition = document.createElement('span');
                                forecastDataCondition.textContent = forecast.forecast.condition;
                                forecastDataCondition.classList = 'forecast-data';
                                forecastData.appendChild(forecastDataCondition);

                                newForecast.appendChild(forecastData);
                                currentConditionElement.appendChild(newForecast);
                            })
                            .catch(err => console.log(err));

                        fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)
                            .then(res => res.json())
                            .then((threeDayForecast) => {
                                upcomingConditionElement.innerHTML = '';
                                let newForecast = document.createElement('div');
                                newForecast.classList = 'forecast-info';

                                for (let i = 0; i < 3; i++) {
                                    let newDayElement = document.createElement('span');
                                    newDayElement.classList = 'upcoming';

                                    let symbolSpan = document.createElement('span');
                                    if (threeDayForecast.forecast[i].condition == 'Rain') {
                                        symbolSpan.textContent = '\u2614';
                                    } else if (threeDayForecast.forecast[i].condition == 'Sunny') {
                                        symbolSpan.textContent = '\u2600';
                                    } else if (threeDayForecast.forecast[i].condition == 'Partly sunny') {
                                        symbolSpan.textContent = '\u26C5';
                                    } else if (threeDayForecast.forecast[i].condition == 'Overcast') {
                                        symbolSpan.textContent = '\u2601';
                                    }
                                    symbolSpan.classList = 'symbol';
                                    newDayElement.appendChild(symbolSpan);

                                    let temperatureSpan = document.createElement('span');
                                    temperatureSpan.textContent = `${threeDayForecast.forecast[i].low}°/${threeDayForecast.forecast[i].high}°`;
                                    temperatureSpan.classList = 'forecast-data';
                                    newDayElement.appendChild(temperatureSpan);

                                    let conditionSpan = document.createElement('span');
                                    conditionSpan.textContent = threeDayForecast.forecast[i].condition;
                                    conditionSpan.classList = 'forecast-data';
                                    newDayElement.appendChild(conditionSpan);

                                    newForecast.appendChild(newDayElement);
                                }
                                upcomingConditionElement.appendChild(newForecast);
                            })
                            .catch(err => console.log(err));
                    }
                }
            })
            .catch(() => {
                currentConditionElement.textContent = 'Error';
                upcomingConditionElement.textContent = 'Error';
            });
    })
}

attachEvents();