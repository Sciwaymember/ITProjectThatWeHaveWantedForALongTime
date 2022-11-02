import React, { useEffect, useState } from 'react'

export default function HomePage() {
  const [searchInput,setSearchInput]=useState(),
    [loading,setLoading]=useState(),//loading is set to undefined when nothing is loading, true if something is loading and false when something is loaded
    [displayedBooks,setDisplayedBooks]=useState();{/* here is where our searched books are displayed, probably moved to different functional component at later stages  */}

    
    let changeInput=(e, input)=>{
      input(e.target.value);
    }
  function changeSearchInput(event){
    setSearchInput(event.target.value)
  }

  async function sumbitSearch(event,input){
    event.preventDefault();
    setLoading(true);
    const response = await fetch('library');
        const data = await response.json();
        setLoading(false);
        if (!data) return setDisplayedBooks("No items were found");
        setDisplayedBooks(data);
  }
  
  return (
    <div>
      <h1>Transleader</h1>
      <input type="text" onChange={e=>changeInput(e,setSearchInput)} placeholder="search for the book you need" value={searchInput || ''}></input>
      <button onClick={e=>sumbitSearch(e,searchInput)}>Find!</button>
      <div>{/* here is where our searched books are displayed, probably moved to different functional component at later stages  */}
      {(loading===undefined)?'':
      (loading===true)?"Loading":
      "Here is the unstyled list of all the books as the search does not work yet:\n "+JSON.stringify(displayedBooks)}
        
      </div>
    </div>
  )
}
