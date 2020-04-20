<template>
  <section class="header-logo">
    <img class="header-logo-img" :src="config.logo || logo" />
    <span class="header-logo-title">{{ config.title }}</span>
  </section>
</template>
<script>
import { mapState } from 'vuex'
import logo from '@assets/logo.png'
export default {
  data() {
    return {
      logo
    }
  },
  computed: {
    ...mapState({ config: s => s.config })
  }
}
</script>
<style lang="scss">
.header-logo {
  width: 200px;

  &-img {
    position: relative;
    top: 12px;
    height: 45px;
  }

  &-title {
    margin-left: 5px;
    font-size: 18px;
    font-weight: 700;
  }
}
</style>
