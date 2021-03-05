<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <div class="d-flex align-center">
        <router-link to="/">
          <v-img
            alt="GoodBooks Logo"
            class="mr-2"
            contain
            src="@/assets/logo_transparent.png"
            transition="scale-transition"
            width="80"
          />
        </router-link>
      </div>

      <v-spacer></v-spacer>

      <v-btn
        to="/books"
        class="mr-4"
        text
      >
        <v-icon class="mr-2">mdi-book</v-icon>
        <span>Books</span>
      </v-btn>

      <v-btn
        href="https://github.com/jboullion/GoodBooks"
        target="_blank"
        text
      >
        <span class="mr-2">Github</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <router-view/>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue';

export default Vue.extend({
  name: 'App',

  components: {
    
  },

  data: () => ({
    //
  }),
});
</script>
