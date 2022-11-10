import React, { useState } from 'react'
import BookList from './components/BookList';

export default function HomePage() {
  const [searchInput,setSearchInput]=useState(),
    [loading,setLoading]=useState(),//loading is set to undefined when nothing is loading, true if something is loading and false when something is loaded
    [displayedBooks,setDisplayedBooks]=useState();//* here is where our searched books are displayed, probably moved to different functional component at later stages  */}

  let changeInput=(e, input)=>{
    input(e.target.value);
  }


  async function sumbitSearch(event,input){
    if (input===undefined) input='';//here it should have a warning message saying that we should input at least something in the field
    event.preventDefault();
    setLoading(true);
    console.log(input);
    const response = await fetch(`http://192.168.1.101:7274/searchbooks?search=${input}`);
    const data = await response.json();
    if (!data) setDisplayedBooks("No items were found");
    else setDisplayedBooks(data); 
    return setLoading(false);
  }
  
  return (
    <div>
      <h1>Transleader</h1>
      <input type="text" onChange={e=>changeInput(e,setSearchInput)} placeholder="search for the book you need" value={searchInput || ''}></input>
      <button onClick={e=>sumbitSearch(e,searchInput)}>Find!</button>
      {/* the input should be placed in separate component because it rerenders the booklist every time you input something into searchbar */}
      <div>
        {/* here is where our searched books are displayed */}
        {(loading===undefined)?'':
        (loading===true)?"Loading":
        <BookList books={displayedBooks}/>}
      </div>
    </div>
  )
}
