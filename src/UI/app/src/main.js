import './styles/app.scss'
import './utils/http'
import { getConfig } from './api/index'
import Vue from 'vue'
import { Button, Dropdown, DropdownItem, DropdownMenu } from 'element-ui'
import './components'
import Layout from './views/layout'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.use(Button)
Vue.use(Dropdown)
Vue.use(DropdownItem)
Vue.use(DropdownMenu)

//请求配置
getConfig().then(config => {
  //设置配置
  store.commit('setConfig', config)
  //设置网站标题
  document.title = config.title

  new Vue({
    router,
    store,
    render: h => h(Layout)
  }).$mount('#app')
})
