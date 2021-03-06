<template>
<v-container>
    <v-row>
        <v-col cols="12">
            <v-card class="mx-auto my-8" >

                <v-img
                height="250"
                :src="`https://picsum.photos/seed/${book.title}/500/250`"
                ></v-img>

                <v-card-title>{{ book.title }}</v-card-title>

                <v-card-text>
                    <div class="my-4 subtitle-1">
                        {{ book.author }}
                    </div>

                    <v-row
                        align="center"
                        class="mx-0"
                    >
                        <v-rating
                        :value="calculatedRating"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="14"
                        ></v-rating>

                        <div class="grey--text ml-4">{{ calculatedRating }} ({{ bookReviews.length }})</div>
                    </v-row>

                </v-card-text>

                <v-divider class="mx-4"></v-divider>

            </v-card>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <h2 class="mb-6">Reviews</h2>

            <div v-if="bookReviews.length">
                <review v-for="review in bookReviews" 
                    :key="review.id" 
                    :review="review"
                    @reloadReviews="loadReviews">
                </review>
            </div>
            <review-form @reloadReviews="loadReviews" :bookId="bookId"></review-form>
        </v-col>
    </v-row>
</v-container>
</template>

<script lang="ts">
import ReviewService from "@/services/review-service";
import Review from "@/components/Review.vue";
import IReview from "@/types/Review";

import ReviewForm from "@/components/ReviewForm.vue";

import BookService from "@/services/book-service";

import { Component, Vue } from 'vue-property-decorator';

const bookService = new BookService();
const reviewService = new ReviewService();

@Component({
    name: 'Book',
    components: { 
        Review,
        ReviewForm
    }
})

export default class Book extends Vue {
    // data
    book = {};
    bookId = 0;
    bookReviews: IReview[] = [];
    calculatedRating = 0;

    // computed properties


    // lifecycle hooks
    created() {
        if(this.$route.params.bookId){
            this.bookId = parseInt(this.$route.params.bookId);
            this.loadBook(this.bookId);
            this.loadReviews();
        }
    }

    loadBook(bookId: number){
        bookService.getBook(bookId)
            .then(res => {
                this.book = res;
            })
            .catch(err => console.error(err));
    }

    loadReviews(){
        reviewService.getAllBookReviews(this.bookId) 
            .then(res => {
                this.bookReviews = res;
                //console.log(this.bookReviews);
                this.calculateRating();
            })
            .catch(err => console.error(err));
    }

    calculateRating(){
        if(this.bookReviews && this.bookReviews.length){
            let totalRating = 0;
            for(let i = 0; i < this.bookReviews.length; i++){
                if(! isNaN(this.bookReviews[i].reviewRating)){
                    totalRating += this.bookReviews[i].reviewRating;
                }
            }

            this.calculatedRating = parseFloat((totalRating / this.bookReviews.length).toFixed(1));
        }
    }

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

 
</style>
