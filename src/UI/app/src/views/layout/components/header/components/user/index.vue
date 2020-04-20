<template>
  <section class="header-user">
    <section v-if="isLogin"></section>
    <section v-else>
      <el-button type="text">登录</el-button>
      <el-button type="text">注册</el-button>
    </section>
  </section>
</template>
<script>
export default {
  data() {
    return {
      isLogin: false
    }
  }
}
</script>
