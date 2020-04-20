const isDev = process.env.NODE_ENV !== 'production'

const config = {
  baseUrl: '/v1/'
}

// 开发模式
if (isDev) {
  config.baseUrl = 'http://localhost:6310/v1/'
}
export default config
