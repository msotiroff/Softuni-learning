<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Film;
use AppBundle\Form\FilmType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class FilmController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $allFilms = $this
            ->getDoctrine()
            ->getRepository('AppBundle:Film')
            ->findAll();

        return $this->render(':film:index.html.twig', ['films' => $allFilms]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $filmToCreate = new Film();

        $form = $this->createForm(FilmType::class, $filmToCreate);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            if ($filmToCreate->getName() == null
                || $filmToCreate->getGenre() == null
                || $filmToCreate->getDirector() == null
                || $filmToCreate->getYear() == null) {
                return $this->redirectToRoute('index');
            }

            if ($filmToCreate->getName() != ""
                && $filmToCreate->getGenre() != ""
                && $filmToCreate->getDirector() != ""
                && $filmToCreate->getYear() != "") {

                $em = $this->getDoctrine()->getManager();
                $em->persist($filmToCreate);
                $em->flush();
            }

            return $this->redirectToRoute('index');
        }

        return $this->render('film/create.html.twig', ['form' => $form->createView()]);
	}

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $filmToEdit = $this->getDoctrine()->getRepository(Film::class)->find($id);

        if ($filmToEdit == null) {
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(FilmType::class, $filmToEdit);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            $em = $this->getDoctrine()->getManager();
            $em->merge($filmToEdit);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('film/edit.html.twig', ['film' => $filmToEdit, 'form' => $form->createView()]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function delete($id, Request $request)
    {
        $filmToDelete = $this->getDoctrine()->getRepository(Film::class)->find($id);

        if ($filmToDelete == null) {
            return $this->redirectToRoute('index');
        }

        $form = $this->createForm(FilmType::class, $filmToDelete);

        $form->handleRequest($request);

        if ($form->isSubmitted() && $form->isValid()) {

            $em = $this->getDoctrine()->getManager();
            $em->remove($filmToDelete);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('film/delete.html.twig', ['film' => $filmToDelete, 'form' => $form->createView()]);
    }
}
