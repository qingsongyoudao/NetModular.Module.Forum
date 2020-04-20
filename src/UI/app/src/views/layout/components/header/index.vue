<template>
  <header class="header">
    <div class="header-wrapper">
      <nm-logo />
      <nm-search />
      <nm-menu />
      <nm-user />
    </div>
  </header>
</template>
<script>
import NmLogo from './components/logo'
import NmSearch from './components/search'
import NmMenu from './components/menu'
import NmUser from './components/user'
export default {
  components: { NmLogo, NmSearch, NmMenu, NmUser }
}
</script>
<style lang="scss">
$header-height: 80px;
.header {
  position: relative;
  border-bottom: solid 1px #e9ecee;
  background-color: #fff;
  z-index: 1;
  height: $header-height;

  &-wrapper {
    margin: 0 auto;
    width: 1200px;
    height: $header-height;

    > section {
      float: left;
      height: $header-height;
      line-height: $header-height;
      box-sizing: border-box;
    }
  }
}
</style>
