import React from 'react'
import { NavMenu } from './NavMenu';
import { Route, Routes} from 'react-router-dom';
import AppRoutes from './AppRoutes';

export default function App() {
  return (
    <div>
        <NavMenu />
    <Routes>
          {AppRoutes.map((route, index) => {
            const { element, ...rest } = route;
            return <Route key={index} {...rest} element={element} />;
          })}
    </Routes>
    </div>
  )
}
// import React, { Component } from 'react';

// export default class App extends Component {
//     static displayName = App.name;

//     constructor(props) {
//         super(props);
//         this.state = { books: [], loading: true };
//     }

//     componentDidMount() {
//         this.populateBooksData();
//     }

//     static renderBooksTable(books) {
//         return (
//             <table className='table table-striped' aria-labelledby="tabelLabel">
//                 <thead>
//                     <tr>
//                         <th>Title</th>
//                         <th>Author</th>
//                         <th>Instance amount</th>
//                     </tr>
//                 </thead>
//                 <tbody>
//                     {books.map(book =>
//                         <tr key={book.title}>
//                             <td>{book.title}</td>
//                             <td>{book.author}</td>
//                             <td>{book.count}</td>
//                         </tr>
//                     )}
//                 </tbody>
//             </table>
//         );
//     }

//     render() {
//         let contents = this.state.loading
//             ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//             : App.renderBooksTable(this.state.books);

//         return (
//             <div>
//                 <h1 id="tabelLabel" >Books Result</h1>
//                 <p>This component demonstrates fetching data from the server.</p>
//                 {contents}
//             </div>
//         );
//     }

//     async populateBooksData() {
//         const response = await fetch('library');
//         const data = await response.json();
//         this.setState({ books: data, loading: false });
//     }
// }