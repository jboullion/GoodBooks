<template>
  <div class="home">
    <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-img
          src="@/assets/logo.png"
          class="my-3"
          contain
          height="200"
        />
      </v-col>

      <v-col class="mb-4">
        <h1 class="display-2 font-weight-bold mb-3">
          Welcome to GoodBooks
        </h1>

        <p class="subheading font-weight-regular">
          All your books R belong to us
        </p>
      </v-col>

    </v-row>
  </v-container>
  </div>
</template>

<script>
// @ is an alias to /src

export default {
  name: 'Home',
  components: {
    
  }
}
</script>

<style lang="scss">
#logo {
  max-width: 100%;
}
</style>