import React from 'react'
import { Link } from 'react-router-dom';

function mapBooks(books){
    return (
        <div>
            {books.map(book => (
               <div key={book.id}> 
                <Link 
                    to={'/book/'+book.id} 
                    style={{ border:`1px solid black`,
                    display: 'block',
                    color:"black",
                    textDecoration:"none"
                    }}>

                    <div> {book.title} </div>
                    <div> {book.author} </div></Link>
               </div>
            ))}
        </div>
      )
}

export default function BookList(books) {
  return (
    <div>
        {mapBooks(books.books)}
    </div>
  )
}
