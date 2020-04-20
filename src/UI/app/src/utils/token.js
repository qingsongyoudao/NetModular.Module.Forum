const TokenKey = 'nm-forum-token'

export default {
  /**
   * 获取令牌
   */
  get() {
    return localStorage.getItem(TokenKey)
  },
  /**
   * 设置令牌
   * @param {String} token 令牌
   */
  set(token) {
    localStorage.setItem(TokenKey, token)
  },
  /**
   * 删除令牌
   */
  remove() {
    localStorage.removeItem(TokenKey)
  }
}
