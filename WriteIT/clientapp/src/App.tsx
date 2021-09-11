import React from 'react';
import logo from './logo.svg';
import './App.css';
import NavAppBarTop from './NavAppBarTop';
import { BrowserRouter, Route } from 'react-router-dom';
import { HomePage } from './Components/HomePage';
import { MoviesPage } from './Components/MoviesPage';
import { SeriesPage } from './Components/SeriesPage';
import { AnimesPage } from './Components/AnimesPage';

function App() {

  return (
    <BrowserRouter>
      <div className="App">
        <NavAppBarTop />
        <Route path='/' component={HomePage} />
        <Route path='/movies' component={MoviesPage} />
        <Route path="/series-tvshows" component={SeriesPage} />
        <Route path="/animes" component={AnimesPage} />
      </div>
    </BrowserRouter>
  );
}

export default App;
