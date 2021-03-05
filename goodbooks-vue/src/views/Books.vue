<template>
  <v-container>
    <v-row class="">
      <v-col cols="12">
        <h1 class="mb-5">My Books
          <v-btn
            to="/add"
            class="mr-4"
              
            >
            <v-icon class="mr-2">mdi-book</v-icon>
            <span>Add Book</span>
          </v-btn>
        </h1>
      </v-col>
    </v-row>
    <v-row v-if="myBooks.length">
      <book v-for="book in myBooks" :key="book.id" :book="book"></book>
    </v-row>
  </v-container>
</template>

<script lang="ts">
  import BookService from "@/services/book-service";
  import IBook from "@/types/Book";
  import Book from "@/components/Book.vue"
  import { Component, Vue } from 'vue-property-decorator';

  const bookService = new BookService();

  @Component({
    name: 'MyBooks',
    components: {
      Book
    }
  })
  export default class MyBooks extends Vue {
    // data
    myBooks: IBook[] = [];

    // computed properties
    get bookCount() {
      return this.myBooks.length
    }

    // lifecycle hooks
    created() {
      bookService.getAllBooks()
        .then(res => {
          this.myBooks = res;
          console.log(this.myBooks);
        })
        .catch(err => console.error(err));
    }

  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
