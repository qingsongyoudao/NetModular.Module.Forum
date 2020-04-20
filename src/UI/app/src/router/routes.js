import Home from '../views/home'
import ErrorPage from '../views/error'
import Error404 from '../views/404'
import Error403 from '../views/403'

export default [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/error',
    name: 'Error',
    component: ErrorPage
  },
  {
    path: '/error/403',
    name: 'Error403',
    component: Error403
  },
  {
    path: '/error/404',
    name: 'Error404',
    component: Error404
  },
  { path: '*', redirect: '/error/404' }
]
