import logo from './logo.svg';
import './App.scss';
import Header from './components/Header';
import ListPost from './components/posts/ListPost';
import Container from 'react-bootstrap/Container';
import { Bounce, ToastContainer } from 'react-toastify';
import LoginForm from './components/LoginForm';
import { Route, Routes, useLocation } from 'react-router-dom';
import DetailPost from './components/posts/DetailPost';
import RegisterApplier from './components/appliers/RegisterApplier';
import RecruiterRegister from './components/recruiters/RecruiterRegister';
import ModalRegister from './components/ModalRegister';
import PersonalPosts from './components/posts/PersonalPosts';


function App() {
  const location = useLocation()
  return (
    <>
      <div className="App">
        {(location.pathname !== "/login" && location.pathname !== "/recruiter-register" && location.pathname !== "/applier-register") && <Header></Header >}
        <Container>
          <Routes>
            <Route path='/' element={<ListPost />}></Route>
            <Route path='/login' element={<LoginForm />}></Route>
            <Route path="/detail-post/:id" element={<DetailPost />}> </Route>
            <Route path='/personal-post' element={<PersonalPosts />}></Route>
            <Route path='/register' element={<ModalRegister />}></Route>
            <Route path='/recruiter-register' element={<RecruiterRegister />}></Route>
            <Route path='/applier-register' element={<RegisterApplier />}></Route>
            <Route></Route>
          </Routes>
        </Container>
      </div>
      <ToastContainer
        position="top-center"
        autoClose={2000}
        limit={2}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="colored"
        transition={Bounce}
      />
    </>
  );
}

export default App;
