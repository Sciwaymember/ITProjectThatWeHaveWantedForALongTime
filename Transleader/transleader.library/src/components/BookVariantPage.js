import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import BookVariantsDropdown from './components/BookVariantsDropdown';

//BookVariantPage /webpath/book/:bookID
// При выборе книги, пользователь получает интерфейс с информацией о книге, а так же кнопкой загрузки данной книги. При этом информация о языке находится в выпадающем меню, при нажатии на которое открывается список доступных для этой книги языков
// (request) Запрос от Library app: GET from ‘/apipath/book/:bookID’
// получает обьект книги {author, description, link to text, link to parent obj, language, optionals}; Необходимы экземпляры запросов с бека для продолжения разработки
// При нажатии на выпадающее меню языков, либо при загрузке страницы после получения данных о книге (link to parent obj) отправляется запрос на получение всех доступных языков и изданий этой книги.
// (request) Запрос от Library app: GET from ‘/apipath/bookVariants/:parentID’
// получает [{language:russian,id:someid}] - массив из книг с двумя основными полями
let tempBackendLink='http://192.168.1.101:7274'

async function fetchIntoSetState(fetchFrom,setState){
  // This function sends a GET request to a server and then puts the responce into a state (first param is endpoint url (without apipath) second param is the function of setting the State you wish to update)
  let fetchUri=tempBackendLink+fetchFrom;
  fetch(fetchUri).then(
    (responce)=>responce.json()).then(
      (data)=>setState(data));
}

export default function BookVariantPage() {
  let {bookID}=useParams();
  const [book,setBook]=useState();  //book object, contains server responce data
  const [bookVariants,setBookVariants]= useState(); //object that is used when user wants to choose a different language (contains dropdown menu options)
  const [langMenuOpen,setLangMenuOpen]=useState(false) //bool, true if language menu is open

  useEffect(()=>{
    setLangMenuOpen(false);
    fetchIntoSetState('/book/'+bookID,setBook);
	},[bookID]);

  useEffect(()=>{
    if (book!==undefined)
      fetchIntoSetState('/bookVariants/'+book["parentID"],setBookVariants)
	},[book]);
  
  if (!book) return (<>Loading</>);
  return (
    <div>
      <h2>{book.title}</h2>
      <h3>{book.author}</h3>
      <h3>{book.publisher?`publisher: ${book.publisher}`:''}</h3>
      <button onClick={()=>setLangMenuOpen(!langMenuOpen)}>{book.language}</button>
      {langMenuOpen ? <BookVariantsDropdown bookVariants={bookVariants}/> : <></>}
      <div>{book.description}</div>
    </div>
  )
}
