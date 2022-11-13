import { Link, Outlet } from "react-router-dom";
import "../App.css"
function Layout() {
    return (
        <div>
            <nav className="navbar navbar-default">
                <div className="container-fluid">
                    <ul className="nav navbar-nav navbar-ul">
                        <li>
                            <Link to='/'>Home</Link>
                        </li>
                        <li>
                            <Link to='/profile'>Profile</Link>
                        </li>
                        <li>
                            <Link to='/students'>Students</Link>
                        </li>
                        <li>
                            <Link to='/books'>Books</Link>
                        </li>
                        <li>
                            <Link to='/login'>Login</Link>
                        </li>
                    </ul>
                </div>
            </nav>
            <Outlet />
        </div>
    );
}
export default Layout;