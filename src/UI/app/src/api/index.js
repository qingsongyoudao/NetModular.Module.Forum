import urls from './urls'

/**
 * @description 获取配置信息
 */
const getConfig = params => {
  return new Promise(resolve => {
    return resolve({
      title: 'NetModular'
    })
  })
  //   return $http.get(urls.config, params)
}

/**
 * @description 注册
 */
const register = params => {
  return $http.post(urls.register, params)
}

export { getConfig, register }
