function MovieDetails(props) {
    return (
        <div className='d-flex align-items-center justify-content-center'>
            <div className='container mt-5'>
                <div className='row'>
                    <div className='col-12 col-md-6 text-center'>
                        <img src={props.movieDetails.poster} alt=''></img>
                    </div>
                    <div className='col-12 col-md-6 text-white'>
                        <h2>{props.movieDetails.title}</h2>
                        <p>{props.movieDetails.year}</p>
                        <p>Rating: {props.movieDetails.imdbRating}</p>
                        <p>{props.movieDetails.plot}</p>
                        <button className='btn btn-danger'
                            onClick={props.closeDetails}>Close</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default MovieDetails;