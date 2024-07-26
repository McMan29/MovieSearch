

function MovieList(props){
    return (
        <>
                {
                    props.movies.map((movie, index) => (
                        <div className='image-container d-flex justify-content-start m-3' style={{ width: 'auto' }} key={index}
                            onClick={e => props.details(movie.imdbID)}>
                            <img src={movie.poster} alt='movie'></img>
                            <div className='overlay d-flex align-items-center justify'></div>
                        </div>
                    ))           
            }
        </>
        )
}

export default MovieList;