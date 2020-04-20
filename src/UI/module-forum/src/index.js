import './api'
import store from './store'
import routes from './routes'
import components from './components'
import module from './module'
// 编辑器
import VueQuillEditor from 'vue-quill-editor'
import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'

export default {
  module,
  routes,
  store,
  components,
  callback({ Vue }) {
    Vue.use(VueQuillEditor)
  }
}
