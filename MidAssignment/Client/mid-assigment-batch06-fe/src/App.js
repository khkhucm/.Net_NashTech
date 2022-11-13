import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home/Home';
import Login from './pages/Login/Login';
import Profile from './pages/Profile/Profile';
import './App.css'
import Layout from './components/layout';
import Books from './pages/Books/Books';

function App() {
  return (
    <div className=''>
      <Routes>
      <Route path='/login' element={<Login />} />
        <Route element={<Layout />}>
          <Route path='/' element={<Home />} />
          <Route path='/profile' element={<Profile />} />
          <Route path='/books' element={<Books />} />
          
        </Route>
        
      </Routes>
    </div>
  );
};


export default App;
