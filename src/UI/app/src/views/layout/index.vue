<template>
  <div id="app">
    <n-header />
    <n-main />
    <n-fotter />
  </div>
</template>
<script>
import NHeader from './components/header'
import NMain from './components/main'
import NFotter from './components/fotter'
export default {
  name: 'App',
  components: { NHeader, NMain, NFotter }
}
</script>
