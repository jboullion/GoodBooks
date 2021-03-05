<template>
  <div class="home">
    <img id="logo" alt="Vue logo" src="../assets/logo.png">
    <HelloWorld msg="GoodBooks 4 Sale"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'

export default {
  name: 'Home',
  components: {
    HelloWorld
  }
}
</script>

<style lang="scss">
#logo {
  max-width: 100%;
}
</style>