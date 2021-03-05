<template>
  <div class="home">
    <HelloWorld msg="All your books R belong to us"/>
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