import React from 'react'
import { Link } from 'react-router-dom'

export default function BookVariantsDropdown(bookVariants) {
  return (
    <div>
        {bookVariants.bookVariants.children.map(book => (
           <div key={book.id}> <Link to={'/book/'+book.id} > {book.language}</Link></div>
        ))}
    </div>
  )
}
