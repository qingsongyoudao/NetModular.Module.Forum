import module from '../../module'

export default name => {
  const root = `${module.code}/${name}/`
  const crud = $http.crud(root)
  const urls = {
    select: root + 'Select',
    sort: root + 'sort'
  }

  const select = () => {
    return $http.get(urls.select)
  }

  const querySortList = parentId => {
    return $http.get(urls.sort, { parentId })
  }

  const updateSortList = params => {
    return $http.post(urls.sort, params)
  }

  return {
    ...crud,
    select,
    querySortList,
    updateSortList
  }
}
