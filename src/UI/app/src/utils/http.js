import axios from 'axios'
import qs from 'qs'
import dayjs from 'dayjs'
import token from './token'
import router from '../router'

axios.defaults.headers.post['Content-Type'] = 'application/json'
axios.defaults.headers.put['Content-Type'] = 'application/json'

function Http() {
  this.axios = axios
}

// 序列化参数为Url形式
Http.prototype.stringify = params => {
  return qs.stringify(params, {
    allowDots: true
  })
}

Http.prototype.post = (url, params, config) => {
  return axios.post(url, params, config)
}

Http.prototype.get = (url, params, config) => {
  const config_ = Object.assign({}, config, {
    // 参数
    params,
    // 修改参数序列化方法
    paramsSerializer: p => {
      // 使用逗号分隔参数
      return qs.stringify(p, {
        allowDots: true
      })
    }
  })
  return axios.get(url, config_)
}

Http.prototype.delete = (url, params, config) => {
  const config_ = Object.assign({}, config, {
    // 参数
    params,
    // 修改参数序列化方法
    paramsSerializer: p => {
      // 使用逗号分隔参数
      return qs.stringify(p, {
        allowDots: true
      })
    }
  })
  return axios.delete(url, config_)
}

Http.prototype.put = (url, params, config) => {
  return axios.put(url, params, config)
}

Http.prototype.download = (url, params, config) => {
  const config_ = Object.assign({ responseType: 'blob' }, config, {
    // 参数
    params,
    // 修改参数序列化方法
    paramsSerializer: p => {
      // 使用逗号分隔参数
      return qs.stringify(p, {
        allowDots: true
      })
    }
  })
  return axios.get(url, config_)
}

Http.prototype.preview = (url, params, config) => {
  const config_ = Object.assign({ responseType: 'blob', headers: { preview: true } }, config, {
    // 参数
    params,
    // 修改参数序列化方法
    paramsSerializer: p => {
      // 使用逗号分隔参数
      return qs.stringify(p, {
        allowDots: true
      })
    }
  })
  return axios.get(url, config_)
}

Http.prototype.export = (url, params, config) => {
  return axios.post(url, params, Object.assign({ responseType: 'blob' }, config))
}

// 通用CRUD接口地址
Http.prototype.crud = root => {
  if (!root.endsWith('/')) {
    root += '/'
  }
  return {
    query(params) {
      return $http.get(`${root}query`, params)
    },
    add(params) {
      return $http.post(`${root}add`, params)
    },
    remove(id) {
      return $http.delete(`${root}delete`, { id })
    },
    edit(id) {
      return $http.get(`${root}edit`, { id })
    },
    update(params) {
      return $http.post(`${root}update`, params)
    }
  }
}

// 设为全局属性$http
if (!window.$http) window.$http = new Http()

//处理文件下载请求
const handleDownload = response => {
  //如果返回的是application/json，则表示返回的是json，没有要下载的问题，可能是逻辑处理失败
  if (response.data.type === 'application/json') {
    var reader = new FileReader()
    reader.onload = e => {
      var data = JSON.parse(e.target.result)
      if (data.code === 1) {
        return data.data
      } else {
        Message.error({
          message: data.msg,
          showClose: true,
          duration: messageDuration
        })
        return
      }
    }
    reader.readAsText(response.data)
    return
  }

  const url = window.URL.createObjectURL(response.data)

  // 如果是预览直接返回
  if (response.config.headers['preview']) return url

  let fileName = ''
  // 如果响应头包含'content-disposition'属性，则从该属性中获取文件名称
  if (response.headers['content-disposition']) {
    fileName = decodeURI(
      response.headers['content-disposition']
        .split(';')
        .find(m => m.trim().startsWith('filename='))
        .split('=')[1]
    )
      .replace('"', '')
      .replace('"', '')
  }

  //如果文件名不存在，则使用时间戳
  if (!fileName) {
    fileName = dayjs().format('YYYYMMDDHHMMSSS')
  }

  //通过模拟a标签点击事件下载文件
  const link = document.createElement('a')
  link.href = url
  link.setAttribute('download', fileName)
  document.body.appendChild(link)
  link.click()
  document.body.removeChild(link)
}

// 初始化
export default config => {
  // 接口根路径
  axios.defaults.baseURL = config.baseUrl

  // 拦截请求
  axios.interceptors.request.use(
    config => {
      let t = token.get()
      if (t && t.accessToken) {
        config.headers.Authorization = 'Bearer ' + t.accessToken
      }
      return config
    },
    function(error) {
      return Promise.reject(error)
    }
  )

  // 响应前拦截器
  axios.interceptors.response.use(
    response => {
      const { config } = response
      // 文件下载/预览
      if (config.responseType && config.responseType === 'blob') {
        return handleDownload(response)
      }

      if (response.data.code === 1) {
        return response.data.data
      } else {
        //请求错误跳转到错误页
        router.push({ name: 'Error' })
      }
    },
    error => {
      let currentRoute = router.currentRoute
      let redirect = currentRoute.name !== 'login' ? currentRoute.fullPath : '/' // 跳转页面

      switch (error.response.status) {
        case 401:
          // 需要登录
          token.remove()
          router.push({
            name: 'login',
            query: {
              redirect
            }
          })
          break
        case 403:
          router.push({
            name: 'Error403'
          })
          break
        default:
          //请求错误跳转到错误页
          router.push({ name: 'Error' })
          break
      }
    }
  )
}
