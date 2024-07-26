import { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import MovieList from './components/MovieList';
import MovieListHeading from './components/MovieListHeading';
import SearchBar from './components/SearchBar';
import MovieDetails from './components/MovieDetails';
import MovieHistory from './components/MovieHistory';

function App() {

    const apiUrl = 'https://localhost:7044/MovieSearch/';
    const [state, setState] = useState({
        search: '',
        result: [],
        selected: {},
        searchHistory: [],
        counter: 0
    });

    const handleInput = (event) => {
        if (event.target) {
            let search = event.target.value
            setState((prevState) => {
                return { ...prevState, search: search }
            })
        }
    }

    const searchMovie = async (event) => {
        if (event.key === "Enter") {
            const url = `${apiUrl}GetMoviebyTitle/${state.search}`;
            const response = await fetch(url);
            const responseJson = await response.json();
            let tempArray = state.searchHistory;
            if (responseJson && responseJson.search) {
                setState((prevState) => {
                    return {
                        ...prevState,
                        result: responseJson.search,
                        counter: state.counter++,
                    }
                });
                if (responseJson.search.length > 0) {
                    if (tempArray.length > 4) {
                        tempArray = tempArray.pop();
                    }
                    tempArray = [{ search: state.search, result: responseJson.search }, ...tempArray]
                    setState((prevState) => {
                        return {
                            ...prevState,
                            searchHistory: tempArray,
                        }
                    })
                }
            }
        }
    }

    const showDetails = async (id) => {
        const url = `${apiUrl}GetMovieDetailsById/${id}`;

        const response = await fetch(url);
        const responseJson = await response.json();

        console.log(responseJson);
        if (responseJson && responseJson.title) {
            setState((prevState) => {
                return { ...prevState, selected: responseJson }
            })
        }
    }

    const closeDetails = () => {
        setState((prevState) => {
            return {
                ...prevState, selected: {} }
        })
    }

    return (
        <div className='container-fluid movie-style'>
            <div className='row d-flex align-itens-center mt-4 mb-4'>
                <MovieListHeading heading={typeof state.selected.title != "undefined" ? "Movie Details" : "Movies Search"}></MovieListHeading>
                <SearchBar search={state.search} setSearch={handleInput} searchMovie={searchMovie} hideSection={typeof state.selected.title != "undefined"} />
            </div>
            <div className='row'>
                {
                    typeof state.selected.title != "undefined" ? <MovieDetails movieDetails={state.selected} closeDetails={closeDetails} /> :
                            <MovieList movies={state.result} details={showDetails}></MovieList>
    
                }
            </div>
            <div className='row' hidden={state.searchHistory.length === 0}>
                <MovieListHeading heading="Lastest Search result"></MovieListHeading>
            </div>
            <div className='movie-history' hidden={state.searchHistory.length === 0}>
                <MovieHistory searchHistory={state.searchHistory} details={showDetails}></MovieHistory>
             </div>
        </div>
    )
}

export default App;