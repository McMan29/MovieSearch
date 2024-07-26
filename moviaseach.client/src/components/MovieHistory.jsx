import MovieList from '../components/MovieList'
//import MovieListHeading from '../components/MovieListHeading'
function MovieHistory(props) {
    return (
        <>
            {
                props.searchHistory.slice().reverse().map((movieHistory, i) => (
                    <div className='movie-history-container' key={`history_main${i}`}>
                        <div className='row' key={`history_header${i}`}>
                            <h3>searched by: {movieHistory.search}</h3>
                        </div>
                        <div className='row' key={`history_list${i}`}>
                            <MovieList movies={movieHistory.result} details={props.details}></MovieList>
                        </div>
                    </div>
                ))
            }
        </>
    )
}

export default MovieHistory;