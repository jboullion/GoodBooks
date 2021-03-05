<template>
  <v-container>
    <v-row class="">
      <v-col cols="12">
        <h1 class="mb-5">Add Books</h1>
      </v-col>
    </v-row>
		<v-form
      ref="form"
      v-model="valid"
      lazy-validation
    >
      <v-text-field
        v-model="name"
        :counter="10"
        :rules="nameRules"
        label="Name"
        required
      ></v-text-field>

      <v-text-field
        v-model="email"
        :rules="emailRules"
        label="E-mail"
        required
      ></v-text-field>

      <v-btn
        :disabled="!valid"
        color="success"
        class="mr-4"
        @click="validate"
      >
        Submit
      </v-btn>

      <v-btn
        color="error"
        class="mr-4"
        @click="reset"
      >
        Reset Form
      </v-btn>
    </v-form>

  </v-container>
</template>

<script lang="ts">
  //import BookService from "@/services/book-service";
  import IBook from "@/types/Book";
  import { Component, Vue } from 'vue-property-decorator';

  //const bookService = new BookService();

  @Component({
    name: 'AddBook',
    components: {
      
    }
  })
  export default class AddBook extends Vue {
    // data
    title = '';
    author = '';
    valid = true;

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
