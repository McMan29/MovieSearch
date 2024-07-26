function SearchBar(props) {
    return (
        <div className='col col-sm-4' hidden={props.hideSection}>
            <input className='form-control'
                value={props.value}
                onChange={props.setSearch}
                onKeyDown={props.searchMovie}
                placeholder='Type movie name to search'>
                
            </input>
        </div>
    )
}

//function SearchBar(props) {
//    return (
//        <div className='col col-sm-4'>
//            <input className='form-control'
//                value={props.value}
//                onChange={(event) => props.setSearch(event.target.value)}
//                placeholder='Type movie name to search'>

//            </input>
//        </div>
//    )
//}

export default SearchBar;