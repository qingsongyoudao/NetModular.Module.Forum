import Vue from 'vue'
import Vuex from 'vuex'
import token from '../utils/token'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    /**配置信息 */
    config: {
      //站点标题
      title: 'NetModular',
      /**logo */
      logo: ''
    },
    /**令牌信息 */
    token: {
      /** 请求令牌 */
      accessToken: '',
      /** 刷新令牌 */
      refreshToken: ''
    }
  },
  mutations: {
    /**
     * @description 设置配置信息
     */
    setConfig(state, config) {
      Object.assign(state.config, config)
    },
    /**
     * @description 从本地存储加载令牌
     */
    loadToken(state) {
      const t = token.get()
      if (t) {
        Object.assign(state.token, t)
      }
    }
  },
  actions: {}
})
