import module from '../../module'

export default name => {
  const root = `${module.code}/${name}/`
  const crud = $http.crud(root)

  return {
    ...crud
  }
}
